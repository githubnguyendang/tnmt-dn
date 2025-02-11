import { Box } from '@mui/material'

interface CheckEffectProps {
  data: any
  type: 'component' | 'string'
}

const CheckEffect = ({ data, type }: CheckEffectProps) => {
  if (data) {
    let licenseStatusComponent
    let licenseStatusText
    switch (data.idLoaiGP) {
      case 5:
        licenseStatusText = 'Giấy phép thu hồi'
        licenseStatusComponent = <div className='license_status hsd-revoked'>{licenseStatusText}</div>
        break
      default:
        switch (data.hieuluc_gp) {
          case 'het-hieu-luc':
            licenseStatusText = 'Hết hiệu lực'
            licenseStatusComponent = <div className='license_status hsd-danger'>{licenseStatusText}</div>
            break
          case 'sap-het-hieu-luc':
            licenseStatusText = 'Sắp hết hiệu lực'
            licenseStatusComponent = <div className='license_status hsd-warning'>{licenseStatusText}</div>
            break
          case 'con-hieu-luc':
            licenseStatusText = 'Còn hiệu lực'
            licenseStatusComponent = <div className='license_status hsd-success'>{licenseStatusText}</div>
            break
          case 'da-bi-thu-hoi':
            licenseStatusText = 'Đã bị thu hồi'
            licenseStatusComponent = <div className='license_status hsd-revoked'>{licenseStatusText}</div>
            break
          default:
            licenseStatusText = 'Không xác định'
            licenseStatusComponent = null
        }
    }

    return type && type == 'component' ? <Box>{licenseStatusComponent}</Box> : licenseStatusText
  }

  return null
}

export default CheckEffect
