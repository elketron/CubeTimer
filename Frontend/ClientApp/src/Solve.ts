import { CubeTypes } from "./CubeTypes";

export interface Solve {
  id: number;
  solvetime: Date;
  type: CubeTypes;
  timeInSeconds: number;
}
