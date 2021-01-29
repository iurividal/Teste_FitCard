using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Teste_FitCard.Models;

namespace Teste_FitCard.Repository
{
    public class EstabelecimentoRepository
    {
        public ConexaoRepository _dbConn { get; set; }

        public EstabelecimentoRepository()
        {
            this._dbConn = new ConexaoRepository();
        }


        public void AddorUpdate(EstabelecimentoModel model)
        {
            using (var db = _dbConn.Conexao)
            {
                // db.Open();
                // var transaction = db.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {

                    if (model.IdEstabelecimento == 0)
                    {
                        //GRAVANDO OS DADOS
                        var pessoa =
                            "INSERT INTO PESSOA(NOMERAZAO, NOMEFANTASIA, DOCUMENTO, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO)VALUES(@NOMERAZAO, @NOMEFANTASIA, @DOCUMENTO, @EMAIL, @TELEFONE, @ENDERECO, @CIDADE, @ESTADO)";

                        db.Execute(pessoa, new
                        {
                            NOMERAZAO = model.NomeRazao,
                            NOMEFANTASIA = model.NomeFantasia,
                            DOCUMENTO = string.Join("", model.CNPJ.ToCharArray().Where(Char.IsDigit)),
                            EMAIL = model.Email,
                            TELEFONE = model.Telefone,
                            ENDERECO = model.Endereco.Logradouro,
                            CIDADE = model.Endereco.Cidade,
                            ESTADO = model.Endereco.Estado
                        });

                        var idpessoa = db.QueryFirst<int>("SELECT MAX(IDPESSOA) FROM PESSOA");

                        db.Execute(
                            @"INSERT INTO ESTABELECIMENTO(IDPESSOA, IDCATEGORIA, DATACADASTRO, STATUS, AGENCIA, CONTACORRENTE)
                                VALUES(@IDPESSOA, @IDCATEGORIA, @DATACADASTRO, @STATUS, @AGENCIA, @CONTACORRENTE)",
                            new
                            {
                                IDPESSOA = idpessoa,
                                IDCATEGORIA = model.Categoria.IdCategoria,
                                DATACADASTRO = model.DataCadastro,
                                STATUS = model.Status,
                                AGENCIA = model.DadosBancario.Agencia,
                                CONTACORRENTE = model.DadosBancario.Conta
                            });

                    }
                    //  transaction.Commit();

                    else
                    {
                        var response = db.QueryFirst("SELECT * FROM ESTABELECIMENTO e WHERE e.IDESTABELECIMENTO = @ID",
                            new { ID = model.IdEstabelecimento });

                        if (response == null) return;


                        var updatePessoa = @"UPDATE PESSOA SET 
                                      NOMERAZAO = @NOMERAZAO, 
                                      NOMEFANTASIA = @NOMEFANTASIA, 
                                      DOCUMENTO = @DOCUMENTO,
                                      EMAIL = @EMAIL,
                                      TELEFONE = @TELEFONE,
                                      ENDERECO = @ENDERECO,
                                      CIDADE = @CIDADE,
                                      ESTADO = @ESTADO
                                      WHERE IDPESSOA = @IDPESSOA";


                        db.Execute(updatePessoa, new
                        {
                            NOMERAZAO = model.NomeRazao,
                            NOMEFANTASIA = model.NomeFantasia,
                            DOCUMENTO = string.Join("", model.CNPJ.ToCharArray().Where(Char.IsDigit)),
                            EMAIL = model.Email,
                            TELEFONE = model.Telefone,
                            ENDERECO = model.Endereco.Logradouro,
                            CIDADE = model.Endereco.Cidade,
                            ESTADO = model.Endereco.Estado,
                            IDPESSOA = response.IDPESSOA
                        });

                        db.Execute(@"UPDATE ESTABELECIMENTO SET IDCATEGORIA = @IDCATEGORIA, 
                              DATACADASTRO = @DATACADASTRO, 
                              STATUS= @STATUS, 
                              AGENCIA = @AGENCIA, 
                              CONTACORRENTE = @CONTACORRENTE
                              WHERE IDESTABELECIMENTO = @IDESTABELECIMENTO", new
                        {

                            IDCATEGORIA = model.Categoria.IdCategoria,
                            DATACADASTRO = model.DataCadastro,
                            STATUS = model.Status,
                            AGENCIA = model.DadosBancario.Agencia,
                            CONTACORRENTE = model.DadosBancario.Conta,
                            IDESTABELECIMENTO = model.IdEstabelecimento

                        });



                    }
                }
                catch (Exception e)
                {
                    // transaction.Rollback();
                    throw new Exception($"Correu um falha ao tentar gravar as informações\n{e.Message}");
                }


            }
        }

        public IEnumerable<EstabelecimentoModel> GetAll()
        {
            using (var db = _dbConn.Conexao)
            {

                var query =
                    @"SELECT P.NOMERAZAO,P.NOMEFANTASIA,P.DOCUMENTO,P.EMAIL,P.TELEFONE,P.ENDERECO,P.CIDADE,P.ESTADO,
                          e.IDESTABELECIMENTO,e.DATACADASTRO,e.STATUS,e.AGENCIA,e.CONTACORRENTE,
                          c.IDCATEGORIA,c.CATEGORIA
                          FROM PESSOA p
                          INNER JOIN ESTABELECIMENTO e ON p.IDPESSOA = e.IDPESSOA
                          INNER JOIN CATEGORIA c ON e.IDCATEGORIA = c.IDCATEGORIA";

                return db.Query(query).Select(item => new EstabelecimentoModel
                {
                    NomeRazao = item.NOMERAZAO,
                    NomeFantasia = item.NOMEFANTASIA,
                    CNPJ = item.DOCUMENTO,
                    Email = item.EMAIL,
                    Telefone = item.TELEFONE,
                    Status = item.STATUS,
                    Endereco = new EnderecoModel
                    {
                        Logradouro = item.ENDERECO,
                        Estado = item.ESTADO,
                        Cidade = item.CIDADE
                    },
                    Categoria = new CategoriaModel
                    {
                        IdCategoria = Convert.ToInt32(item.IDCATEGORIA),
                        Categoria = item.CATEGORIA
                    },
                    DadosBancario = new BancoModel
                    {
                        Conta = item.CONTACORRENTE,
                        Agencia = item.AGENCIA
                    },
                    DataCadastro = item.DATACADASTRO,
                    IdEstabelecimento = Convert.ToInt32(item.IDESTABELECIMENTO)


                }).OrderBy(a => a.IdEstabelecimento);

            }
        }

        public void Delete(int id)
        {
            using (var db = _dbConn.Conexao)
            {
                var response = db.QueryFirst("SELECT * FROM ESTABELECIMENTO WHERE IDESTABELECIMENTO = @IDESTABELECIMENTO", new { IDESTABELECIMENTO = id });

                if (response == null) return;


                db.Execute("DELETE FROM ESTABELECIMENTO WHERE IDESTABELECIMENTO = @IDESTABELECIMENTO",
                                    new { IDESTABELECIMENTO = id });

                db.Execute("DELETE FROM PESSOA WHERE IDPESSOA = @IDPESSOA", new { IDPESSOA = response.IDPESSOA });


            }
        }
    }
}