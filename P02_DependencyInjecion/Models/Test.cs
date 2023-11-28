﻿namespace P02_DependencyInjecion.Models
{
    public class Test : ITest
    {
        public Data Data { get; set; }
        public Test()
        {
            Data = new();
            GenerateData();
        }
        public Data GenerateData()
        {
            Data.Id = GetHashCode();
            Data.Message = "Test";
            return Data;
        }
    }
}
