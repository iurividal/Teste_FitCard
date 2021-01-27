using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using Teste_FitCard.Models;

namespace Teste_FitCard.Repository
{
    public class CategoriaRepository
    {
        public IEnumerable<CategoriaModel> GetCategoria()
        {
            using (var db = new ConexaoRepository().Conexao)
            {
                return db.Query<CategoriaModel>("SELECT IDCATEGORIA,CATEGORIA FROM CATEGORIA WHERE DTAEXCLUSAO is null order by IDCATEGORIA");
            }
        }

        public void AddOrUpdate(CategoriaModel categoria)
        {
            using (var db = new ConexaoRepository().Conexao)
            {
                var result = db.Query("SELECT IDCATEGORIA,CATEGORIA FROM CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA",
                    new { IDCATEGORIA = categoria.IdCategoria });

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        db.Execute("UPDATE CATEGORIA SET CATEGORIA = @CATEGORIA WHERE IDCATEGORIA = @IDCATEGORIA",
                            new { CATEGORIA = categoria.Categoria, IDCATEGORIA = categoria.IdCategoria });
                    }
                }
                else
                {
                    db.Execute("INSERT INTO dbo.CATEGORIA(CATEGORIA)VALUES(@CATEGORIA)",
                        new { CATEGORIA = categoria.Categoria });
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new ConexaoRepository().Conexao)
            {
                db.Execute("UPDATE dbo.CATEGORIA SET DTAEXCLUSAO = @DATE WHERE IDCATEGORIA  = @IDCATEGORIA", new { IDCATEGORIA = id, DATE = DateTime.Now });
            }
        }
    }
}