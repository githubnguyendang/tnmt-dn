import { Typography } from '@mui/material'
import { useEffect, useState } from 'react'
import { getData } from 'src/api/axios'
import jwt_decode from 'jwt-decode'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import TableComponent from 'src/@core/components/table'

// id of columnsTable is parameter to bind ex: get LicseFk.BasinId: id: 'License_Fk.BasinId'
const columnsTable = [
  { id: 'ftpAddress', label: 'Địa chỉ FTP', align: 'center' },
  { id: 'username', label: 'Tài khoản',  align: 'center' },
  { id: 'password', label: 'Mật khẩu',  align: 'center' },
  { id: 'cameraLink', label: 'Đường dẫn Camera',  align: 'center' },
  { id: 'protocol', label: 'Giao thức truyền',  align: 'center' },
  { id: 'port', label: 'Cổng kết nối FTP', align: 'center' }
]

interface DecodedToken {
  [key: string]: any
}

const RequestTableDetails = () => {
  const [resData, setResData] = useState<any[]>([])
  const [columns, setColumns] = useState<any[]>([])

  const [userName, setUserName] = useState<string | null>(null)
  const { getAuthToken } = useRequireAuth()
  const token = getAuthToken()


  useEffect(() => {
    setResData([])
    setColumns(columnsTable)

    if (token) {
      const decodedToken = jwt_decode(token) as DecodedToken
      setUserName(decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'])
    }

    // fetchData();

    const getTransmissionAccounts = async () => {
      getData('DataTransmissionAccounts/'+`${userName}`)
        .then(data => {
            setResData(data)
        })
        .catch(error => {
          console.log(error)
        })
    }

    getTransmissionAccounts()
  }, [token, userName])

  return (
    <fieldset className='field-request-info'>
      <legend>
        <Typography variant={'subtitle1'} className='legend__title'>
          Tài khoản kết nối đến công trình
        </Typography>
      </legend>
      <TableComponent columns={columns} rows={resData} />
    </fieldset>
  )
}

export default RequestTableDetails
