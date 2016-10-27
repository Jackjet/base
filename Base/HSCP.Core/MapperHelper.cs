/****************************************************** 

    文件名称：MapperHelper.cs
    功能描述：AutoMapper helper
    作    者：Jxw
    日    期：2016.04.26
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Conan.Core
{
    public class MapperHelper<Tsource, Tdestination> where Tsource : class, new() where Tdestination : class, new()
    {
        MapperConfiguration _mcfg;

        public MapperHelper()
        {
            _mcfg = new MapperConfiguration(cfg => { cfg.CreateMap<Tsource, Tdestination>(); });
        }

        public Tdestination Mappe(Tsource source)
        {
            var mapper = _mcfg.CreateMapper();
            return mapper.Map<Tsource, Tdestination>(source);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tsou"></typeparam>
        /// <typeparam name="Tdes"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public Tdes Mappe<Tsou, Tdes>(Tsou source)
        {
            var mapper = _mcfg.CreateMapper();
            return mapper.Map<Tsou, Tdes>(source);
        }
    }

    public class Mappers {
        public static Tdes DynamicMap<Tdes>(dynamic source) where Tdes : class, new()
        {
            return Mapper.DynamicMap<Tdes>(source);
        }

        public static Tdes Mappe<Tsou, Tdes>(Tsou source) where Tdes : class, new() where Tsou : class, new()
        {
            return Mapper.Map<Tdes>(source);
        }
    }


}