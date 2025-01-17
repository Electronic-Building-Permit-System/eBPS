export interface CharkillaModel {
    direction: string;
    side: string;
    roadName: string;
    landscapeType: string | number; // Assuming this is an ID
    roadLength: number;
    existingRow: string;
    actualSetback: string;
  }