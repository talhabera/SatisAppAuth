using AutoMapper;
using System.Reflection;

namespace PaymentCheckApi.Service.Application.Shared;
public static class ApplicationExtensions
{

	public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector, string propName)
	{
		foreach (var parent in source)
		{
			yield return parent;

			var children = selector(parent);
			foreach (var child in SelectRecursive(children, selector, propName))
			{
				PropertyInfo prop = parent.GetType().GetProperty(propName);
				prop.SetValue(parent, children);
				// PropertyInfo propertyInfo = child.GetType().GetProperty("Parent");
				//propertyInfo.SetValue(child, Convert.ChangeType(null, propertyInfo.PropertyType), null);
				yield return child;
			}
		}
	}


	public static TModel Mapping<T, TModel>(this T source)
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<T, TModel>();
		});
		var mapper = new Mapper(config);
		var destination = (TModel)Activator.CreateInstance(typeof(TModel));
		mapper.Map(source, destination);
		return destination;
	}

	public static TModel ModelMapping<T, TModel>(this T source, TModel destination)
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<T, TModel>().IgnoreAllNonExisting();
		});

		var mapper = new Mapper(config);
		mapper.Map(source, destination);
		return destination;
	}

	public static TModel MappingByConfig<T, TModel>(this T source, TModel destination, Action<IMapperConfigurationExpression> configure)
	{
		var config = new MapperConfiguration(configure);
		var mapper = new Mapper(config);
		mapper.Map(source, destination);
		return destination;
	}

	public static TModel MappingByConfig<T, TModel>(this T source, Action<IMapperConfigurationExpression> configure)
	{
		var config = new MapperConfiguration(configure);
		var mapper = new Mapper(config);
		var destination = (TModel)Activator.CreateInstance(typeof(TModel));
		mapper.Map(source, destination);
		return destination;
	}

	public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
(this IMappingExpression<TSource, TDestination> expression)
	{
		var flags = BindingFlags.Public | BindingFlags.Instance;
		var sourceType = typeof(TSource);
		var destinationProperties = typeof(TDestination).GetProperties(flags);

		foreach (var property in destinationProperties)
		{
			if (sourceType.GetProperty(property.Name, flags) == null)
			{
				expression.ForMember(property.Name, opt => opt.Ignore());
			}
		}
		return expression;
	}

}

