using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels;

public class EntityBase<T> where T : IEquatable<T>
{
  public T Id { get; set; } = default!;
}
