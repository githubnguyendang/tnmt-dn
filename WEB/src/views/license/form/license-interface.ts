import { Dayjs } from 'dayjs'
import { BusinessState } from 'src/views/business/form/business-fieldset'
import { ConstructionState } from 'src/views/construction/form/construction-interface'
import { LicenseFeeState } from 'src/views/license-fee/form/license-fee-interface'

export interface LicenseState {
  id?: number | null
  idCon?: number | null
  idLoaiGP?: number | null
  idTCCN?: number | null
  idCT?: number | null
  tenGP: string | null
  soGP: string | null
  ngayKy: Dayjs | null
  ngayCoHieuLuc: Dayjs | null
  ngayHetHieuLuc: Dayjs | null
  thoiHan: string | null
  coQuanCapPhep: string | null
  fileGiayPhep: string | null
  fileGiayToLienQuan: string | null
  fileDonXinCP: string | null
  congtrinh: ConstructionState | null
  tochuc_canhan: BusinessState | null
  tiencq: LicenseFeeState[] | null
}

export const emptyLicenseData = {
  id: 0,
  idCon: null,
  idLoaiGP: null,
  idTCCN: null,
  idCT: null,
  tenGP: null,
  soGP: null,
  ngayKy: null,
  ngayCoHieuLuc: null,
  ngayHetHieuLuc: null,
  thoiHan: null,
  coQuanCapPhep: null,
  fileGiayPhep: null,
  fileGiayToLienQuan: null,
  fileDonXinCP: null,
  congtrinh: null,
  tochuc_canhan: null,
  tiencq: null
}

export interface FormLicenseProps {
  data: any
  closeDialogs: () => void
  setPostSuccess?: (value: boolean) => void
}

export interface LicenseFieldsetProps {
  data?: any
  onChange: (data: LicenseState, fileUpload?: any) => void
}
