export interface GifData {
  type: string;
  id: string;
  url: string;
  title: string;
  images: Images;
}

export interface Images {
  original: Original;
}

export interface Original {
  url: string;
  width: string;
  height: string;
  size: string;
}

