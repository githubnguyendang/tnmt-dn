import Paper from '@mui/material/Paper'
import { Box, Grid, IconButton, Typography } from '@mui/material'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import Header from '../../header'
import Footer from '../../footer'
import { Delete, Edit } from '@mui/icons-material'
import { getData } from 'src/api/axios'

const ExploitSurfaceWater = () => {
  const [data, setData] = useState<any[]>([])
  const [loading, setLoading] = useState(false)

  const columnsTable: TableColumn[] = [
    {
      id: 'stt',
      label: 'STT'
    },
    {
      id: '#',
      label: 'Tên chủ hộ/Công trình',
      elm: (row: any) => row?.ten_ct
    },
    {
      id: '#',
      label: 'Tọa độ(VN2000)',
      children: [
        {
          id: 'x',
          label: 'Tọa độ X',
          elm: (row: any) => row?.x
        },
        {
          id: 'y',
          label: 'Tọa độ Y',
          elm: (row: any) => row?.y
        }
      ]
    },
    {
      id: '#',
      label: 'Vị trí hành chính',
      children: [
        {
          id: 'xa',
          label: 'Xã',
          elm: (row: any) =>
            row?.xa?.map((x: any, key: number, arr: any[]) => (
              <Typography key={key}>
                {x?.tenXa}
                {key < arr.length - 1 ? ', ' : ''}
              </Typography>
            )),
          minWidth: 180
        },
        {
          id: 'huyen',
          label: 'Huyện',
          elm: (row: any) =>
            row?.huyen?.map((h: any, key: number, arr: any[]) => (
              <Typography key={key}>
                {h?.tenHuyen}
                {key < arr.length - 1 ? ', ' : ''}
              </Typography>
            )),
          minWidth: 180
        },
        {
          id: 'tinh',
          label: 'Tỉnh'
        }
      ]
    },
    {
      id: '#',
      label: 'Thuộc lưu vực sông',
      children: [{ id: 'lv_song', label: '(6)', elm: (row: any) => row?.lv_song }]
    },
    {
      id: 'loai_ct',
      label: 'Loại công trình',
      elm: (row: any) => row?.loai_ct
    },
    {
      id: 'nguonnuoc_kt',
      label: 'Nguồn nước khai thác',
      elm: (row: any) => row?.nguonnuoc_kt
    },
    {
      id: 'mucdich_kt',
      label: 'Mục đích sử dụng nước',
      elm: (row: any) => row?.mucdich_kt
    },
    {
      id: 'dungtich_ho',
      align: 'center',
      label: (<span>Dung tích<br />hồ chứa, đập dâng <br/> (triệu m3)</span>),
      
      elm: (row: any) => row?.dungtich_ho
    },
    {
      id: 'q_kt_tuoi',
      align: 'center',
      label: (<span>Lưu lượng <br />khai thác <br/> với mục đích tưới <br/>(m3/s) </span>),
      elm: (row: any) => row?.q_kt_tuoi
    },
    {
      id: 'q_kt_kddv_sx_phi_nn',
      align: 'center',
      label: (
        <span>
          Lưu lượng khai thác <br/> đối với mục đích <br /> kinh doanh dịch vụ <br/> và sản xuất phi nông nghiệp <br /> (m3/ngày
          đêm)
        </span>
      ),
      elm: (row: any) => row?.q_kt_kddv_sx_phi_nn
    },
    {
      id: 'congsuat',
      align: 'center',
      label: (<span> Công suất <br/> phát điện <br/> (KW)</span>),
      elm: (row: any) => row?.congsuat
    },
    {
      id: 'mucdich_khac',
      align: 'center',
      label: (<span> Mục đích <br/> khai thác <br/> (m3/ngày đêm)</span>),
      elm: (row: any) => row?.mucdich_khac
    },
    {
      id: '#',
      align: 'center',
      label: (<span> Ghi chú </span>),
    }
  ]

  useEffect(() => {
    async function getDataExploitWater() {
      setLoading(true)
      await getData(`NM_KhaiThacSuDung/danh-sach`)
        .then(data => {
          setData(data)
        })
        .catch(error => {
          console.log(error)
        })
        .finally(() => {
          setLoading(false)
        })
    }

    getDataExploitWater()
  }, [])

  return (
    <Paper sx={{ p: 8 }}>
      <Header />

      <Grid className='_text_center'>
        <Typography className='font-weight-bold' variant='body1' textTransform={'uppercase'}>
          KIỂM KÊ KHAI THÁC, SỬ DỤNG NƯỚC MẶT
        </Typography>
        <Typography className='font-weight-bold' variant='subtitle2'>
          (Hồ chứa, đập dâng có dung tích toàn bộ &#8805; 0,01 triệu m3; Công trình khai thác , sử dụng nước mặt khác
          cho mục đích sản suất nông nghiệp, nuôi trồng thủy sản với quy mô {'>'} 0,1 m3/s; <br />
          Khai thác nước mặt cho kinh doanh, sản suất phi nông nghiệp là {'>'} 100m3/ngày đêm và phát điện với công suất{' '}
          {'>'} 50KW)
        </Typography>
      </Grid>
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid className='_text_center' sx={{ mt: 3 }}>
          <TableComponent
            columns={columnsTable}
            rows={data}
            loading={loading}
            pagination
            actions={() => (
              <Box className='group_btn'>
                <IconButton>
                  <Edit />
                </IconButton>
                <IconButton>
                  <Delete />
                </IconButton>
              </Box>
            )}
          />
        </Grid>
      )}

      <Footer />
    </Paper>
  )
}

export default ExploitSurfaceWater
