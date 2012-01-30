﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Cassette.Configuration
{
    class BundleContainerFactory : BundleContainerFactoryBase
    {
        public BundleContainerFactory(IDictionary<Type, IBundleFactory<Bundle>> factories, CassetteSettings settings)
            : base(factories, settings)
        {
        }

        public override IBundleContainer Create(IEnumerable<Bundle> unprocessedBundles)
        {
            var bundlesArray = unprocessedBundles.ToArray();
            ProcessAllBundles(bundlesArray);
            var externalBundles = CreateExternalBundlesUrlReferences(bundlesArray);
            return new BundleContainer(bundlesArray.Concat(externalBundles));
        }
    }
}