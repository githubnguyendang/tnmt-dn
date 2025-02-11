//React Imports
import React, { useState, useEffect, useRef } from 'react'

//MUI Imports
import { Typography, Paper, Grid, Box, FormGroup, FormControlLabel, Checkbox } from '@mui/material'

//Other Imports
import CheckEffect from 'src/views/license/check-effect'

// import MapComponent from 'src/@core/components/map';
import CountLicense from 'src/views/license/count-license'
import ShowFilePDF from 'src/@core/components/show-file-pdf'
import CreateLicense from './form'

import dynamic from 'next/dynamic'
import { useRouter } from 'next/router'
import LicenseToolBar from './tool-bar'
import { getData } from 'src/api/axios'
import DeleteData from 'src/@core/components/delete-data'
import GetConstructionTypeId from 'src/@core/components/get-construction-type'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { ConverterCood } from 'src/@core/components/map/convert-coord'
import { formatDate, formatNum } from 'src/@core/components/formater'
import MapLegendLicense from 'src/views/license/MapLegendLicense'
import AlertDialog from './detail'

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false })

const ListLicenses = () => {
  const [mapCenter, setMapCenter] = useState([15.012172, 108.676488])
  const [mapZoom, setMapZoom] = useState(9)
  const [showLabel, setShowLabel] = useState(false)
  const [mapData, setMapData] = useState<any[]>([])

  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }
  const [loading, setLoading] = useState(false)
  const [resData, setResData] = useState([])

  const zoomConstruction = (coords: any) => {
    setMapCenter(coords)
    setMapZoom(13)
    window.scrollTo({
      top: 0,
      left: 0,
      behavior: 'smooth'
    })
  }

  const router = useRouter()

  //Init columnTable
  const columnsTable: TableColumn[] = [
    { id: 'stt', label: 'STT', align: 'center' },
    {
      id: 'soGP',
      label: 'Số GP',
      align: 'left',
      pinned: 'left',
      minWidth: 200,
      elm: (row: any) => <AlertDialog data={row} />
      // elm: (row: any) => <ShowFilePDF name={row?.soGP} src={row?.fileGiayPhep} />
    },
    { id: 'ngayKy', label: 'Ngày ký', align: 'left', minWidth: 200, elm: (row: any) => formatDate(row?.ngayKy) },
    {
      id: 'hieuluc_gp',
      label: 'Hiệu lực GP',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => CheckEffect({ data: row, type: 'component' })
    },
    {
      id: 'ngayCoHieuLuc',
      label: 'Ngày có hiệu lực',
      align: 'left',
      minWidth: 200,
      elm: (row: any) => formatDate(row?.ngayCoHieuLuc)
    },
    { id: 'thoiHan', label: 'Thời hạn cấp phép', align: 'left', minWidth: 200, elm: (row: any) => row?.thoiHan },
    {
      id: 'tochuc_canhan',
      label: 'Cơ quan/cá nhân được CP',
      align: 'left',
      children: [
        { id: 'tenTCCN', label: 'Tên', align: 'left', minWidth: 400, elm: (row: any) => row?.tochuc_canhan?.tenTCCN },
        { id: 'diaChi', label: 'Địa chỉ', align: 'left', minWidth: 400, elm: (row: any) => row?.tochuc_canhan?.diaChi }
      ]
    },
    {
      id: 'lichSuCapPhep',
      label: 'Giấy phép liên quan',
      align: 'left',
      elm: (row: any) =>
        row.lichSuCapPhep?.map((e: any, i: number) =>
          row.id != e.id ? (
            <React.Fragment key={i}>
              <ShowFilePDF
                name={`${e?.soGP}(${formatDate(e?.ngayKy)}) - ${CheckEffect({ data: e, type: 'string' })} `}
                src={e?.fileGiayPhep}
              />
            </React.Fragment>
          ) : null
        )
    },
    {
      id: 'congtrinh',
      label: 'Công trình',
      align: 'left',
      children: [
        {
          id: 'tenCT',
          label: 'Tên',
          align: 'left',
          minWidth: 300,
          elm: (row: any) => (
            <Typography
              className='btnShowFilePdf'
              onClick={() => zoomConstruction(ConverterCood(row?.congtrinh.y, row?.congtrinh.x))}>
              {row?.congtrinh?.tenCT}
            </Typography>
          )
        },
        { id: 'viTriCT', label: 'Địa điểm', align: 'left', minWidth: 300, elm: (row: any) => row?.congtrinh?.viTriCT },
        {
          id: 'loaiCT-tenLoaiCT',
          label: 'Loại công trình',
          align: 'left',
          minWidth: 200,
          elm: (row: any) => row?.congtrinh?.loaiCT?.tenLoaiCT
        },
        {
          id: 'nguonNuocKT',
          label: 'Nguồn nước khai thác',
          align: 'left',
          minWidth: 300,
          elm: (row: any) => row?.congtrinh?.nguonNuocKT
        },
        {
          id: 'luuvuc',
          label: 'Lưu vực',
          align: 'left',
          minWidth: 200,
          elm: (row: any) => row?.congtrinh?.luuvuc?.tenLVS
        },
        {
          id: 'mucdich_kt',
          label: 'Lưu lượng cấp phép',
          align: 'left',
          children: [
            {
              id: 'mucDich',
              label: 'Mục đích',
              align: 'left',
              minWidth: 350,
              elm: (row: any) =>
                row?.congtrinh?.mucdich_kt?.map((e: any, key: number, arr: any[]) => (
                  <Box key={key}>
                    {e.mucDich}
                    {key < arr.length - 1 ? ', ' : ''}
                  </Box>
                ))
            },
            {
              id: 'luuLuong',
              label: 'Lưu lượng',
              align: 'center',
              minWidth: 150,
              elm: (row: any) => (row?.congtrinh?.tongLuuLuong == 0 ? null : row?.congtrinh?.tongLuuLuong)
            },
            {
              id: 'donViTinhLuuLuong',
              label: 'Đơn vị đo',
              align: 'center',
              minWidth: 150,
              elm: (row: any) => row?.congtrinh?.donViTinhLuuLuong
            }
          ]
        }
      ]
    },
    {
      id: 'tiencq',
      label: 'Tiền cấp quyền',
      align: 'left',
      children: [
        {
          id: 'soQDTCQ',
          label: 'Số QĐ',
          align: 'left',
          minWidth: 200,
          elm: (row: any) =>
            row?.tiencq?.map((e: any, key: number) => <ShowFilePDF key={key} name={e.soQDTCQ} src={e.filePDF} />)
        },
        {
          id: 'ngayKy',
          label: 'Ngày ký',
          align: 'left',
          minWidth: 200,
          elm: (row: any) =>
            row?.tiencq?.map((e: any, key: number) => (
              <Typography key={key} sx={{ fontSize: 14 }}>
                {formatDate(e.ngayKy)}
              </Typography>
            ))
        },
        {
          id: 'tongTienCQ',
          label: 'Tổng tiền',
          align: 'left',
          minWidth: 200,
          elm: (row: any) =>
            row?.tiencq?.map((e: any, key: number) => (
              <Typography key={key} sx={{ fontSize: 14 }}>
                {formatNum(e.tongTienCQ)}
              </Typography>
            ))
        }
      ]
    },
    { id: 'actions', label: '#', align: 'center', pinned: 'right' }
  ]

  const [paramsFilter, setParamsFilter] = useState({
    so_gp: null,
    cong_trinh: null,
    coquan_cp: (router.query.coquan_cp as string) || null,
    loaihinh_cp: 0,
    hieuluc_gp: (router.query.hieuluc_gp as string) || null,
    loai_ct: Number(router.query.loai_ct) || GetConstructionTypeId(router),
    tang_chuanuoc: 0,
    huyen: 0,
    xa: 0,
    tieuvung_qh: 0,
    tochuc_canhan: 0,
    tu_nam: new Date().getFullYear() - 50,
    den_nam: new Date().getFullYear()
  })

  const isMounted = useRef(true)

  const getDataLicense = async () => {
    setLoading(true)
    getData('giay-phep/danh-sach', paramsFilter)
      .then(data => {
        if (isMounted.current) {
          setResData(data)

          // Tạo một mảng mới để chứa các phần tử có tên là Construction
          const newArray: any[] = []

          // Lọc mảng License theo tên
          const filteredArray = data.filter((item: any) => item.congtrinh)

          // Duyệt qua mảng đã lọc và kiểm tra xem phần tử đó đã có trong mảng mới chưa
          // Nếu chưa có, thì đẩy nó vào mảng mới
          filteredArray.forEach((item: any) => {
            // Check if item.congtrinh is not already in newArray based on its id
            const existsInNewArray = newArray.some((c: any) => c.id === item.congtrinh.id)

            if (!existsInNewArray) {
              newArray.push(item.congtrinh)
            }
          })

          // In ra mảng mới
          setMapData(newArray)
        }
      })
      .catch(error => {
        console.log(error)
      })
      .finally(() => {
        setLoading(false)
      })
  }

  useEffect(() => {
    isMounted.current = true

    return () => {
      isMounted.current = false
    }
  }, [])

  useEffect(() => {
    getDataLicense()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [postSuccess, paramsFilter])

  const handleFilterChange = (data: any, postSuccess: boolean | undefined) => {
    setParamsFilter(data)
    if (postSuccess !== undefined) {
      setPostSuccess(postSuccess)
    }
  }

  useEffect(() => {
    if (router.query.hieuluc_gp || router.query.loai_ct) {
      setParamsFilter(prev => ({
        ...prev,
        hieuluc_gp: (router.query.hieuluc_gp as string) || prev.hieuluc_gp,
        loai_ct: Number(router.query.loai_ct) || prev.loai_ct
      }))
    }
  }, [router.query])

  return (
    <Box>
      <Grid container>
        <Grid item xs={12} md={12}>
          <Paper sx={{ py: 1, px: 3 }}>
            <Typography variant='overline'>
              Cấp phép/
              {GetConstructionTypeId(router) == 1
                ? 'Nước mặt'
                : GetConstructionTypeId(router) == 3
                ? 'Xả thải'
                : GetConstructionTypeId(router) == 7
                ? 'Nước dưới đất/Khai thác sử dụng'
                : GetConstructionTypeId(router) == 8
                ? 'Nước dưới đất/Thăm dò'
                : GetConstructionTypeId(router) == 9
                ? 'Nước dưới đất/Hành nghề khoan'
                : ''}
            </Typography>
          </Paper>
        </Grid>
      </Grid>
      <Grid container sx={{ height: '45vh', my: 3 }} columnSpacing={3}>
        <Grid item xs={12} md={3}>
          <Paper sx={{ height: '100%' }}>
            <CountLicense data={resData} />
          </Paper>
        </Grid>
        <Grid item xs={12} md={9} sx={{ position: 'relative' }}>
          <Paper sx={{ height: '100%', p: 1 }}>
            <Box
              className='map-legend-license'
              sx={{ background: 'white', pl: 2, zIndex: 999, height: 'auto', top: '15px' }}>
              <FormGroup>
                <FormControlLabel
                  sx={{ m: 0 }}
                  control={<Checkbox sx={{ p: 1 }} onClick={() => setShowLabel(!showLabel)} />}
                  label='Hiển thị tên công trình'
                />
              </FormGroup>
              <MapLegendLicense />
            </Box>
            <Map center={mapCenter} showLabel={showLabel} zoom={mapZoom} mapData={mapData} />
          </Paper>
          {/* <Paper  sx={{ py: 1, px: 3, position: 'absolute', top: 20, left: 20, bottom: 8, right: '70%', zIndex: 1000, display: 'flex', alignItems: 'center' }}>
                    <CountLicense data={resData} />
                </Paper> */}
        </Grid>
      </Grid>

      <Grid container spacing={3}>
        <Grid item xs={12} md={12}>
          <Paper sx={{ p: 0, height: '100%' }}>
            <LicenseToolBar onChange={handleFilterChange} onExport={{ id: 'license-data', fileName: 'license-data' }} />
            <TableComponent
              id='license-data'
              columns={columnsTable}
              rows={resData}
              loading={loading}
              pagination
              actions={(row: any) => (
                <Box className='group_btn'>
                  <CreateLicense isEdit={true} data={row} setPostSuccess={handlePostSuccess} />
                  <DeleteData url={'giay-phep'} data={row} setPostSuccess={handlePostSuccess} />
                </Box>
              )}
            />
          </Paper>
        </Grid>
      </Grid>
    </Box>
  )
}

export default ListLicenses
