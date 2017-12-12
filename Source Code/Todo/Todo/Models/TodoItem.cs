using SQLite;

namespace Todo
{
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        public string kode { get; set; }
		public string Nama { get; set; }
		public string Catatan { get; set; }
		public bool Done { get; set; }
	}
}

