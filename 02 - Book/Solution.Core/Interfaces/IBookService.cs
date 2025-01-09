﻿using ErrorOr;
using Solution.Core.Models;

namespace Solution.Core.Interfaces;

public interface IBookService
{
    Task<ErrorOr<BookModel>> CreateAsync(BookModel model);
}
