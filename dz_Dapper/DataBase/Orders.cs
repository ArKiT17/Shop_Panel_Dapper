using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_Dapper.DataBase {
	internal class Orders {
		public int Id { get; set; }
		public int UsersId { get; set; }
		public int ItemsId { get; set; }
		public int Count { get; set; }
		public string Delivery { get; set; }
		public string Status { get; set; }
	}
}
