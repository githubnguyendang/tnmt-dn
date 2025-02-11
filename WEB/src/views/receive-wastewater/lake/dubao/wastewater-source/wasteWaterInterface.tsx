export interface FormDuLieuNguonNhanDBState {
  id: number
  idPhanDoanSong: number
  idMucPL: number
  luuLuongDongChayDB: number
  cnnBODDB: number
  cnnCODDB: number
  cnnAmoniDB: number
  cnnTongNDB: number
  cnnTongPDB: number
  cnnTSSDB: number
  cnnColiformDB: number
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
