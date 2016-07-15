using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESistema.Geo
{
    class JsonWebService
    {

    }
    public class Properties
    {
        public int id { get; set; }
        public object idcapa_documento { get; set; }
        public string clase { get; set; }
        public int idgeo { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public object cruzamiento1 { get; set; }
        public object cruzamiento2 { get; set; }
        public string colonia { get; set; }
    }
    public class Feature
    {
        public Properties properties { get; set; }
    }
    public class ResponseJsonGeo
    {
        public List<Feature> features { get; set; }
    }
}
