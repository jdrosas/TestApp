export interface HistoryData {
    id: number;
    dateSearch: Date;
    factInfo: string;
    factQuery: string;
    urlGif: string;
}

export interface HistoryCreateData {
    dateSearch: string;
    factInfo: string;
    factQuery: string;
    urlGif: string;
}
