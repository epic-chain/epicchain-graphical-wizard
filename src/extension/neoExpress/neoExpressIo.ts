import * as neonSc from "@cityofzion/neon-core/lib/sc";

import BlockchainIdentifier from "../blockchainIdentifier";
import JSONC from "../util/JSONC";
import Log from "../util/log";
import EpicChainExpress from "./EpicChainExpress";

const LOG_PREFIX = "EpicChainExpressIo";

export default class EpicChainExpressIo {
  static async contractGet(
    EpicChainExpress: EpicChainExpress,
    identifer: BlockchainIdentifier,
    hashOrNefPath: string
  ): Promise<neonSc.ContractManifestJson | null> {
    if (identifer.blockchainType !== "express") {
      return null;
    }
    const output = await EpicChainExpress.run(
      "contract",
      "get",
      hashOrNefPath,
      "-i",
      identifer.configPath
    );
    if (output.isError || !output.message) {
      return null;
    }
    try {
      return JSONC.parse(output.message) as neonSc.ContractManifestJson;
    } catch (e) {
      throw Error(`Get contract error: ${e.message}`);
    }
  }

  static async contractList(
    EpicChainExpress: EpicChainExpress,
    identifer: BlockchainIdentifier
  ): Promise<{
    [name: string]: { hash: string };
  }> {
    if (identifer.blockchainType !== "express") {
      return {};
    }
    const output = await EpicChainExpress.run(
      "contract",
      "list",
      "-i",
      identifer.configPath,
      "--json"
    );
    if (output.isError) {
      Log.error(LOG_PREFIX, "List contract invoke error", output.message);
      return {};
    }
    try {
      let result: {
        [name: string]: { hash: string };
      } = {};
      let contractSummaries = JSONC.parse(output.message);
      for (const contractSummary of contractSummaries) {
        const hash = contractSummary.hash;
        result[contractSummary.name] = { hash };
      }
      return result;
    } catch (e) {
      throw Error(`List contract parse error: ${e.message}`);
    }
  }

  static async contractStorage(
    EpicChainExpress: EpicChainExpress,
    identifer: BlockchainIdentifier,
    contractName: string
  ): Promise<{ key?: string; value?: string; constant?: boolean }[]> {
    if (identifer.blockchainType !== "express") {
      return [];
    }
    const output = await EpicChainExpress.run(
      "contract",
      "storage",
      contractName,
      "-i",
      identifer.configPath,
      "--json"
    );
    if (output.isError) {
      Log.error(LOG_PREFIX, "Contract storage retrieval error", output.message);
      throw Error(output.message);
    }
    try {
      return (
        ((JSONC.parse(output.message).storages || []) as {
          key?: string;
          value?: string;
          constant?: boolean;
        }[]) || []
      );
    } catch (e) {
      throw Error(`Contract storage parse error: ${e.message}`);
    }
  }
}
