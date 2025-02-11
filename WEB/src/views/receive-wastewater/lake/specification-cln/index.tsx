//React Imports
import React, { useEffect, useState } from 'react'
import Grid from '@mui/material/Unstable_Grid2'
import SpecCLNTable from './clnTable'
import { Typography } from '@mui/material'
import { useRouter } from 'next/router'
import { CLNState } from './clnInterface'
import { getData } from 'src/api/axios'
import BoxLoading from 'src/@core/components/box-loading'

const SpecCLN = () => {
  const route = useRouter()
  const [data, setData] = useState<CLNState[]>([])
  const [loading, setLoading] = useState(false)
  const [postSuccess, setPostSuccess] = useState(false)
  const handlePostSuccess = () => {
    setPostSuccess(prevState => !prevState)
  }

  useEffect(() => {
    async function getDataReport1() {
      setLoading(true)

      if (route.pathname.split('/')[3] === 'nguon-nuoc-ao') {
        try {
          const data = await getData('ThongSoCLNAo/danhsach')
          setData(data)
        } catch (error) {
          console.error(error)
        }
      }
      if (route.pathname.split('/')[3] === 'nguon-nuoc-song') {
        try {
          const data = await getData('ThongSoCLNSong/danhsach')
          setData(data)
        } catch (error) {
          console.error(error)
        }
      }

      setLoading(false)
    }

    getDataReport1()
  }, [route.pathname, postSuccess])

  return (
    <Grid container spacing={2}>
      <Grid xs={12} md={12}>
        <Typography textAlign={'center'} variant='h6'>
          QCVN 08:2023/BTNMT
        </Typography>
        <Typography sx={{ mt: 5 }} textAlign={'center'} variant='h6'>
          QUY CHUẨN KỸ THUẬT QUỐC GIA
          <br />
          VỀ CHẤT LƯỢNG NƯỚC MẶT
        </Typography>
        <Typography sx={{ mt: 5 }} textAlign={'center'} variant='h6'>
          National technical regulation on Surface water quality
        </Typography>
      </Grid>
      {loading ? <BoxLoading /> : <SpecCLNTable data={data} setPostSuccess={handlePostSuccess} />}
    </Grid>
  )
}

export default SpecCLN
