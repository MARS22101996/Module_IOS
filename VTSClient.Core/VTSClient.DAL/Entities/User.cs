﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VTSClient.DAL.Entities
{
	public class User 
	{
		[PrimaryKey]
		public Guid Id { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }
	}
}
