using System;
using System.Web.Routing;

namespace ByndyuSoft.Infrastructure.Web.Routing
{
	///<summary>
	/// Методы расширения для коллекции маршрутов
	///</summary>
	public static class RouteCollectionExtensions
	{
		/// <summary>
		/// Добавить маршрут, который будет отсылать постоянное перенаправления на заданный маршрут
		/// </summary>
		/// <param name="routes">Коллекция маршрутов для ASP.NET</param>
		/// <param name="url">Шаблон URL для заданного маршрута</param>
		/// <param name="values"></param>
		public static void MapRedirectToRoutePermanent(this RouteCollection routes, string url, object values)
		{
			routes.Add(new Route(url, new RedirectToRoutePermanentHandler(values)));
		}
	}
}