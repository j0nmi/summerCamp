export interface IHistorial {
    "id": string;
    "idUsuario": string;
    "cantidad": number|any;
    "moneda1": string;
    "moneda2": string;
    "resultadoConversion": number|any;
    "fechaConversion": string;
    "factorConversion": number|string|null
  }