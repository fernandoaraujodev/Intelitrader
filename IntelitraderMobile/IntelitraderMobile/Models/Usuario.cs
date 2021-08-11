﻿using System;
using System.Text.Json.Serialization;

namespace IntelitraderMobile.Models
{
    public class Usuario
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonPropertyName("sexo")]
        public int Sexo { get; set; }

        [JsonPropertyName("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("dataAlteracao")]
        public DateTime DataAlteracao { get; set; }
    }
}