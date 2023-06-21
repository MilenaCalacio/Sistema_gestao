﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL
{
    public class FornecedorBLL
    {
        public void Inserir(Fornecedor _fornecedor)
        {
            new FornecedorDAL().Inserir(_fornecedor);
        } 

        public Fornecedor BuscarPorId(int _id)
        {
            return new FornecedorDAL().BuscarPorId(_id);
        } 

        public List<Fornecedor> BuscarPorNome(string _nome)
        {
            return new FornecedorDAL().BuscarPorNome(_nome);
        } 

        public List<Fornecedor> BuscarPorTodos()
        {
            return new FornecedorDAL().BuscarPorTodos();
        } 

        public List<Fornecedor> BuscarPorSite(string _site)
        {
            return new FornecedorDAL().BuscarPorSite(_site);
        } 
        public void Alterar(Fornecedor _fornecedor)
        {
            new FornecedorDAL().Alterar(_fornecedor);
        }

        public void Excluir(int _id)
        {
            new FornecedorDAL().Excluir(_id);
        } 
       


    }
}

