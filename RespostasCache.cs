//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeLightBible
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    
    public partial class RespostasCache
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string Embedding { get; set; }


        [NotMapped]
        public float[] EmbeddingArray
        {
            get => string.IsNullOrEmpty(Embedding) ? Array.Empty<float>() : JsonConvert.DeserializeObject<float[]>(Embedding);
            set => Embedding = JsonConvert.SerializeObject(value);
        }
    }
}
