export interface Game {
  Id: string;
  name: string;
  price: number;
  unitInStock: number;
  discontinued: boolean;
  releaseDate: string;
  imageKey: string;
  genre: string;
  categoryId: string;
  description: string;
}
