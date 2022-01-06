using crud_series.Interface;

namespace crud_series.Classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();
        public void Atualizar(int id, Series entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Series entidade)
        {
           listaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
           return listaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}