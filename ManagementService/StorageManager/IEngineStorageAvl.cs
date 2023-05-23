﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager
{
    public interface IEngineStorageAvl
    {
        public void AddEngine(string name, string path);
        public Dictionary<string, string> GetEngines();
        public string GetEnginePath(string name);
    }
}