﻿using System;

namespace RH_Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public FuncionarioViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Escolaridade { get; set; }
        public string Curso { get; set; }
        public string AreaFuncional { get; set; }
    }
}
