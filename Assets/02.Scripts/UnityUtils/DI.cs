using System;
using System.Collections.Generic;
using System.Linq;
using Object = System.Object;

namespace EAUtils {
	public static class DI {
		private static Dictionary<Type, Object> instances = new Dictionary<Type, object>();

		static DI(){ 
			Log.i("DI", "initializing the dependency injector");
		}
        
		/*
		 * Register any type of class in the dependency manager
		 */
		public static void Register<T>(T component){
			Log.i("DI", $"Registering component type {typeof(T)}");
			instances[component.GetType()] = component;
		}

		/*
		 * Get the object based on the type that has been previously registered
		 */
		public static T Get<T>(){
			PrintDi();
			T i;
			try{
				i = instances.Select(component => component.Value).OfType<T>().FirstOrDefault();
			}
			catch (Exception e){
				Log.i("DI", "exception in getting the game manager");
				return default;
			}
			Log.i("DI", $"successfully got the type {typeof(T).FullName}");
			return i;
		}

		private static void PrintDi(){
			foreach (var (key, value) in instances.Select(x => (x.Key, x.Value))){
				Log.i("DI",$"Type={key}, Value={value}");
			}
		}
	}

}