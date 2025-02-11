export interface FormDuLieuNguonNhanState {
  id: number
  idPhanDoanSong: number
  luuLuongDongChay: number
  cnnBOD: number
  cnnCOD: number
  cnnAmoni: number
  cnnTongN: number
  cnnTongP: number
  cnnTSS: number
  cnnColiform: number
  cqcBOD: number
  cqcCOD: number
  cqcAmoni: number
  cqcTongN: number
  cqcTongP: number
  cqcTSS: number
  cqcColiform: number
  ghiChu: string
}

export interface FormDuLieuThongSoDQTState {
  id: number
  idDiemQT:number
  dot: string
  ph: number
  do: number
  tss: string
  bod: string
  cod: string
  nO3: string
  nO2: string
  pO4: string
  nH4: string
  cl: string
  fe: string
  coliform: number
  year: number
}
