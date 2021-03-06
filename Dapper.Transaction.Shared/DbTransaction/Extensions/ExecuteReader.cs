﻿using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute parameterized SQL and return an <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="sql">The SQL to execute.</param>
		/// <param name="param">The parameters to use for this command.</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An <see cref="IDataReader"/> that can be used to iterate over the results of the SQL query.</returns>
		/// <remarks>
		/// This is typically used when the results of a query are not processed by Dapper, for example, used to fill a <see cref="DataTable"/>
		/// or <see cref="T:DataSet"/>.
		/// </remarks>
		/// <example>
		/// <code>
		/// <![CDATA[
		/// DataTable table = new DataTable("MyTable");
		/// using (var reader = ExecuteReader(cnn, sql, param))
		/// {
		///     table.Load(reader);
		/// }
		/// ]]>
		/// </code>
		/// </example>
		public static IDataReader ExecuteReader(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteReader(sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Execute parameterized SQL and return an <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="cnn">The connection to execute on.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>An <see cref="IDataReader"/> that can be used to iterate over the results of the SQL query.</returns>
		/// <remarks>
		/// This is typically used when the results of a query are not processed by Dapper, for example, used to fill a <see cref="DataTable"/>
		/// or <see cref="T:DataSet"/>.
		/// </remarks>
		public static IDataReader ExecuteReader(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteReader(command);
		} 

		/// <summary>
		/// Execute parameterized SQL and return an <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="cnn">The connection to execute on.</param>
		/// <param name="command">The command to execute.</param>
		/// <param name="commandBehavior">The <see cref="CommandBehavior"/> flags for this reader.</param>
		/// <returns>An <see cref="IDataReader"/> that can be used to iterate over the results of the SQL query.</returns>
		/// <remarks>
		/// This is typically used when the results of a query are not processed by Dapper, for example, used to fill a <see cref="DataTable"/>
		/// or <see cref="T:DataSet"/>.
		/// </remarks>
		public static IDataReader ExecuteReader(this IDbTransaction transaction, CommandDefinition command, CommandBehavior commandBehavior)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteReader(command, commandBehavior);
		}
	}
}
