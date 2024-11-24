﻿using EpicChain.VM;
using EpicChainTraceVisualizer.ModelAdapters;
using System;



namespace EpicChainTraceVisualizer
{
    partial class InteropService
    {
        public void RegisterAsset(Action<string, Func<ExecutionEngine, bool>, int> register)
        {
            register("EpicChain.Asset.Create", Asset_Create, 0);
            register("EpicChain.Asset.Renew", Asset_Renew, 0);
            register("EpicChain.Asset.GetAssetId", Asset_GetAssetId, 1);
            register("EpicChain.Asset.GetAssetType", Asset_GetAssetType, 1);
            register("EpicChain.Asset.GetAmount", Asset_GetAmount, 1);
            register("EpicChain.Asset.GetAvailable", Asset_GetAvailable, 1);
            register("EpicChain.Asset.GetPrecision", Asset_GetPrecision, 1);
            register("EpicChain.Asset.GetOwner", Asset_GetOwner, 1);
            register("EpicChain.Asset.GetAdmin", Asset_GetAdmin, 1);
            register("EpicChain.Asset.GetIssuer", Asset_GetIssuer, 1);

            register("AntShares.Asset.Create", Asset_Create, 0);
            register("AntShares.Asset.Renew", Asset_Renew, 0);
            register("AntShares.Asset.GetAssetId", Asset_GetAssetId, 1);
            register("AntShares.Asset.GetAssetType", Asset_GetAssetType, 1);
            register("AntShares.Asset.GetAmount", Asset_GetAmount, 1);
            register("AntShares.Asset.GetAvailable", Asset_GetAvailable, 1);
            register("AntShares.Asset.GetPrecision", Asset_GetPrecision, 1);
            register("AntShares.Asset.GetOwner", Asset_GetOwner, 1);
            register("AntShares.Asset.GetAdmin", Asset_GetAdmin, 1);
            register("AntShares.Asset.GetIssuer", Asset_GetIssuer, 1);
        }

        private bool Asset_GetAssetId(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetAssetId(engine));
        }

        private bool Asset_GetAssetType(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetAssetType(engine));
        }

        private bool Asset_GetAmount(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetAmount(engine));
        }

        private bool Asset_GetAvailable(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetAvailable(engine));
        }

        private bool Asset_GetPrecision(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetPrecision(engine));
        }

        private bool Asset_GetOwner(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetOwner(engine));
        }

        private bool Asset_GetAdmin(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetAdmin(engine));
        }

        private bool Asset_GetIssuer(ExecutionEngine engine)
        {
            return engine.TryAdapterOperation<AssetAdapter>(adapter => adapter.GetIssuer(engine));
        }

        private bool Asset_Create(ExecutionEngine engine)
        {
            throw new NotImplementedException(nameof(Asset_Create));
        }

        private bool Asset_Renew(ExecutionEngine engine)
        {
            throw new NotImplementedException(nameof(Asset_Renew));
        }
    }
}
