using System;
using System.Runtime.Serialization;

namespace DomainAssemblage.Exceptions
{
    public class TrancheNotDetermined : Exception
    {
        public TrancheNotDetermined(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public TrancheNotDetermined(string trancheEvaluatorName, string context = null)
        {
            TrancheEvaluatorName = trancheEvaluatorName;
            Context = context ?? Context;
        }

        public string TrancheEvaluatorName { get; private set; }
        public string Context { get; private set; }

        public override string Message => "Tranche Evaluator " + TrancheEvaluatorName + " did not determine a tranche.  Context: " + Context;
    }
}
