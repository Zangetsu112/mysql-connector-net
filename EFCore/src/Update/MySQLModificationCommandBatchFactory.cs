// Copyright (c) 2015, 2020 Oracle and/or its affiliates.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License, version 2.0, as
// published by the Free Software Foundation.
//
// This program is also distributed with certain software (including
// but not limited to OpenSSL) that is licensed under separate terms,
// as designated in a particular file or component or in included license
// documentation.  The authors of MySQL hereby grant you an
// additional permission to link the program and your derivative works
// with the separately licensed software that they have included with
// MySQL.
//
// Without limiting anything contained in the foregoing, this file,
// which is part of MySQL Connector/NET, is also subject to the
// Universal FOSS Exception, version 1.0, a copy of which can be found at
// http://oss.oracle.com/licenses/universal-foss-exception.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License, version 2.0, for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Update;
using MySql.Data.EntityFrameworkCore.Infrastructure.Internal;
using MySql.Data.EntityFrameworkCore.Utils;
using System.Linq;

namespace MySql.Data.EntityFrameworkCore.Update
{
  /// <summary>
  /// IModificationCommandBatchFactory implemntation for MySQL
  /// </summary>
  internal class MySQLModificationCommandBatchFactory : IModificationCommandBatchFactory
  {
    private readonly ModificationCommandBatchFactoryDependencies _dependencies;
    private readonly IDbContextOptions _options;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public MySQLModificationCommandBatchFactory(
            [NotNull] ModificationCommandBatchFactoryDependencies dependencies,
            [NotNull] IDbContextOptions options)
    {
      Check.NotNull(dependencies, nameof(dependencies));
      Check.NotNull(options, nameof(options));

      _dependencies = dependencies;
      _options = options;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual ModificationCommandBatch Create()
    {
      var optionsExtension = _options.Extensions.OfType<MySQLOptionsExtension>().FirstOrDefault();

      return new MySQLModificationCommandBatch(_dependencies, optionsExtension?.MaxBatchSize);
    }
  }
}
