using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework.DB;
using BlackFireFramework.Unity;

public class StorageDemo : MonoBehaviour
{
	private IEnumerator Start()
	{
		var connection = BlackFire.Storage.CreateConnection("Test",Application.dataPath+"/Demo/Storage/demo.db");
		
		var doCreate = connection.CheckOrCreateTable<User>();

		if (doCreate)
		{
			for (int i = 0; i < 20; i++)
			{
				connection.Insert(new User(){ Account = "Alan_"+i,Password = "abc123"});
				yield return null;
			}
		}

		var list = connection.Query<User>("select Id from User where Account=?","Alan_19");

		for (int i = 0; i < list.Count; i++)
		{
			Debug.Log(list[i].Id+"  "+list[i].Account+"  "+list[i].Password);
		}
		
		Debug.Log("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
		
		list = connection.Query<User>("select * from User where Account=?","Alan_19");

		for (int i = 0; i < list.Count; i++)
		{
			Debug.Log(list[i].Id+"  "+list[i].Account+"  "+list[i].Password);
		}
		
		Debug.Log("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
		
		list = connection.Query<User>("select * from User where Id>=15 order by Id desc limit 0,1");

		for (int i = 0; i < list.Count; i++)
		{
			Debug.Log(list[i].Id+"  "+list[i].Account+"  "+list[i].Password);
		}
		
	}
	
	
	
	
}

/// <summary>
/// 用户表。
/// </summary>
public sealed class User
{
	[AutoIncrement][PrimaryKey] public int Id { get; set; }
	public string Account { get; set; }
	public string Password { get; set; }
}
