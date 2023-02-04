using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TestingDomain.Users;

namespace TestingDomain.Users
{
	/// <summary>
	/// Builder for the class <see cref="User">User</see>
	/// </summary>
	public class UserBuilder
	{
		private string firstName;
		private string lastName;
		private string middleName;
		private ICollection<Order> orders;

		/// <summary>
		/// Create a new instance for the <see cref="UserBuilder">UserBuilder</see>
		/// </summary>
		public UserBuilder()
		{
			Reset();
		}

		/// <summary>
		/// Reset all properties' to the default value
		/// </summary>
		/// <returns>Returns the <see cref="UserBuilder">UserBuilder</see> with the properties reseted</returns>
		public UserBuilder Reset()
		{
			firstName = default;
			lastName = default;
			middleName = default;
			orders = new Collection<Order>();

			return this;
		}

		/// <summary>
		/// Set a value of type <see cref="ICollection{T}" /> of <see cref="Order" /> for the property <paramref name="orders">orders</paramref>
		/// </summary>
		/// <param name="orders">A value of type ICollection of Order will the defined for the property</param>
		/// <returns>Returns the <see cref="UserBuilder" /> with the property <paramref name="orders">orders</paramref> defined</returns>
		public UserBuilder WithOrders(ICollection<Order> orders)
		{
			this.orders = orders;
			return this;
		}

		/// <summary>
		/// An item of type <see cref="Order"/> will be added to the collection Orders
		/// </summary>
		/// <param name="item">A value of type Order will the added to the collection</param>
		/// <returns>Returns the <see cref="UserBuilder" /> with the collection Orders with one more item</returns>
		public UserBuilder WithOrdersItem(Order item)
		{
			orders.Add(item);
			return this;
		}

		/// <summary>
		/// Build a class of type <see cref="User">User</see> with all the defined values
		/// </summary>
		/// <returns>Returns a <see cref="User">User</see> class</returns>
		public User Build()
		{
			return new User
			{
				FirstName = firstName,
				LastName = lastName,
				MiddleName = middleName,
				Orders = orders,
			};
		}
	}
}