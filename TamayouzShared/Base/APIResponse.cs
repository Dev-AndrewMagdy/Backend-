﻿namespace TamayouzShared.Base
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T? Data { get; set; }
    }
}
