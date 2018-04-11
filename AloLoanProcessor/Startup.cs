﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloLoanTrancheEvaluation.LoanTrancheEvaluators;
using AloLoanTrancheEvaluation.TrancheEvaluationProcessors;
using DomainAssemblage.Entities;
using DomainAssemblage.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AloLoanProcessor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LoanTrancheEvaluator, CorLoanTrancheEvaluator>(
                ctx =>
                {
                    return GetWiredUpCorLoanTrancheEvaluator();
                }
            );

            services.AddMvc();
        }

        private CorLoanTrancheEvaluator GetWiredUpCorLoanTrancheEvaluator()
        {
            return new CorLoanTrancheEvaluator(
                new List<Func<LoanProduct, Tuple<bool, Tranche>>>
                {
                    GetLouisianaLoanTrancheEvaluator(),
                    new IllinoisLoanTrancheEvaluator().GetTranche,
                    new MaineLoanTrancheEvaluator().GetTranche,
                    new NewYorkLoanTrancheEvaluator().GetTranche,
                    new MissippiLoanTrancheEvaluator().GetTranche
                }
            );
        }

        private Func<LoanProduct, Tuple<bool, Tranche>> GetLouisianaLoanTrancheEvaluator()
        {
            if (FeatureToggles.PostKatrina) 
            {
                return new PostKatrinaLouisianaLoanTrancheEvaluator(
                    new SecretSauceMdaDeterminer.SecretSauceMdaDeterminer()
                )
                    .GetTranche;    
            }

            return new LouisianaLoanTrancheEvaluator().GetTranche;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
