export enum TransactionTypeEnum {
  VacantLand = 1,
  Superstructure = 2,
  Completion = 3,
  Niyemit = 4,
}

export const TransactionTypeDescriptions: { [key: number]: string } = {
  [TransactionTypeEnum.VacantLand]: 'Application for Vacant Land',
  [TransactionTypeEnum.Superstructure]: 'Application for Super Structure',
  [TransactionTypeEnum.Completion]: 'Application for Completion',
  [TransactionTypeEnum.Niyemit]: 'Application for Niyemit',
};
