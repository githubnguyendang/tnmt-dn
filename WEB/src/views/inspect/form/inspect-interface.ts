import { Dayjs } from 'dayjs'

export interface InspectState {
  id?: number | null | undefined
  soVanBan: string | null | undefined
  thoiGian: Dayjs | null | undefined
  tienPhat: number | null | undefined
  dot: string | null | undefined
  donVi: string | null | undefined
  ghiChu: string | null | undefined
  taiLieu: string | null | undefined
  daXoa: boolean | undefined
  fileUpload?: File | null | undefined
}

export const emptyInspectData: InspectState = {
  soVanBan: '',
  thoiGian: null,
  tienPhat: 0,
  dot: '',
  donVi: '',
  ghiChu: '',
  taiLieu: null,
  daXoa: false,
  fileUpload: null
}
