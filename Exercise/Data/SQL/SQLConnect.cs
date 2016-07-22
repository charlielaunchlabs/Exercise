using System;
using SQLite.Net;

namespace Exercise
{
	public interface SQLConnect
	{

		SQLiteConnection GetConnection();

	}

}