using System;
using Newtonsoft.Json;

namespace IronFoundry.Model
{
    [Serializable]
    public class Staging : EntityBase
    {
        private string model;
        private string stack;

        [JsonProperty(PropertyName = "model")]
        public string Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged("Model"); }
        }

        [JsonProperty(PropertyName = "stack")]
        public string Stack
        {
            get { return stack; }
            set { stack = value; RaisePropertyChanged("Stack"); }
        }
    }
}