using ConexaoBD;
using Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estoque.Classes
{
    public class Açoes
    {


        public List<Produto> GridTudo()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaAll();

            List<Produto> Produto = new List<Produto>();
            foreach (DataRow dr in dt.Rows)
            {
                Produto.Add(new Produto
                {
                    idProduto = @dr["idProduto"].ToString().ToUpper(),
                    nomeProduto = @dr["nomeProduto"].ToString().ToUpper(),
                    descricao = @dr["descricao"].ToString().ToUpper(),
                    quantidade = @dr["quantidade"].ToString().ToUpper(),
                    Categorias_id = @dr["Categorias_id"].ToString().ToUpper(),
                    nome_categoria = @dr["nm_categoria"].ToString().ToUpper(),

                });
            }
            return (Produto);
        }

        public string AddCategoria(string nomeCategoria)
        {
            if(nomeCategoria != "")
            {
                Busca b = new Busca();
                b.AddCategoria(nomeCategoria);
                return ("Categoria Adicionada com Sucesso");
            }else
            {
                return ("Digite um nome válido");
            }
           
        }

        public List<SelectListItem> GetCategorias()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaCategorias();
            List<SelectListItem> categorias = new List<SelectListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                categorias.Add(new SelectListItem { Text = @dr["nm_categoria"].ToString(), Value = @dr["id"].ToString() });
            }

            return (categorias);
        }

        public List<Categoria> GridCategorias()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaCategorias();

            List<Categoria> categorias = new List<Categoria>();
            foreach (DataRow dr in dt.Rows)
            {
                categorias.Add(new Categoria
                {
                    id = @dr["id"].ToString().ToUpper(),
                    nm_categoria = @dr["nm_categoria"].ToString().ToUpper(),

                });
            }
            return (categorias);
        }

        public string DelCategoria(string id)
        {
            if(id != "")
            {
                Busca b = new Busca();
                b.DeleteCategoria(id);
                return ("Categoria apagada com sucesso");
            }else
            {
                return ("Selecione uma categoria válida");
            }
           
        }

        public string UpdateCategoria(string id, string name)
        {
            if ((id != "") &&(name!=""))
            {
                Busca b = new Busca();
                b.UpdateCategoria(id, name);
                return ("Nome da categoria atualizada com sucesso");
            }else
            {
                return ("Digite um nome válido");
            }
           

        }

        public string AddProduto(string nome, string descr, string categoria, string quantidade)
        {
            if ((nome !="")&&(descr!="")&&(categoria!="")&&(quantidade!=""))
            {
                Busca b = new Busca();
                b.AddProduto(nome, descr, categoria, quantidade);
                return ("Produto adicionado com sucesso");
            }
            else
            {
                return ("Digite valores válidos");
            }
            
        }

        public List<SelectListItem> GetProdutos()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaProdutos();
            List<SelectListItem> categorias = new List<SelectListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                categorias.Add(new SelectListItem { Text = @dr["nomeProduto"].ToString(), Value = @dr["idProduto"].ToString() });
            }

            return (categorias);
        }

        public string UpadteProduto(string id, string nome, string cat, string desc, string qtd)
        {
            Busca b = new Busca();

            if (id == "")
            {
                return ("Produto não selecionado");
                    }
            else if ((nome != "") && (cat != "") && (desc != "") && (qtd != ""))
            {
                b.UpdateProduto(id, nome, cat, desc, qtd);
                return ("TODOS OS CAMPOS ATUALIZADOS");

            }
            else if ((nome!="") && (cat!="")&&(desc!="") &&(qtd == ""))
            {
                b.UpdateProdutoName(id,nome);
                b.UpdateProdutoCat(id, cat);
                b.UpdateProdutoDesc(id, desc);
                return ("Campos nome , categoria e descrição atualizados");
            }else if ((nome != "") && (cat != "") && (desc == "") && (qtd == ""))
            {
                b.UpdateProdutoName(id, nome);
                b.UpdateProdutoCat(id, cat);
                return ("Campos nome e categoria  atualizados");
            }else if ((nome == "") && (cat == "") && (desc != "") && (qtd != ""))
            {
                b.UpdateProdutoQtd(id, qtd);
                b.UpdateProdutoDesc(id, desc);
                return ("Campos descrição e quantidade  atualizados");
            }else if ((nome == "") && (cat != "") && (desc != "") && (qtd == ""))
            {
                b.UpdateProdutoCat(id, cat);
                b.UpdateProdutoDesc(id, desc);
                return ("Campos categoria e descrição atualizados");
            }else if ((nome != "") && (cat == "") && (desc == "") && (qtd != ""))
            {
                b.UpdateProdutoName(id, nome);
                b.UpdateProdutoQtd(id, qtd);
                return ("Campos nome e quantidade atualizados");
            }else if ((nome != "") && (cat == "") && (desc != "") && (qtd == ""))
            {
                b.UpdateProdutoName(id, nome);
                b.UpdateProdutoDesc(id, desc);
                return ("Campos nome e descrição atualizados");
            }else if ((nome == "") && (cat != "") && (desc == "") && (qtd != ""))
            {
                b.UpdateProdutoCat(id, cat);
                b.UpdateProdutoQtd(id, qtd);
                return ("Campos categoria e quantidade atualizados");
            }else if ((nome != "") && (cat == "") && (desc == "") && (qtd == ""))
            {
                b.UpdateProdutoName(id, nome);
                return ("Campo nome atualizado");

            }else if((nome == "") && (cat != "") && (desc == "") && (qtd == ""))
            {
                b.UpdateProdutoCat(id,cat);
                return ("Campo categoria atualizado");
            }else if ((nome == "") && (cat == "") && (desc != "") && (qtd == ""))
            {
                b.UpdateProdutoDesc(id, desc);
                return ("Campo descrição atualizado");
            }else if ((nome == "") && (cat == "") && (desc == "") && (qtd != ""))
            {
                b.UpdateProdutoQtd(id, qtd);
                return ("Campo quantidade atualizado");
            }else
            {
                return ("Nenhum campo preenchido");
            }
        }

        public string DelProduto(string id)
        {
            Busca b = new Busca();

            if( id != ""){
                b.DeleteProduto(id);
                return ("Produto Apagado com Sucesso");
            }else
            {
                return ("Produto Inválido");
            }
        }
    }
}