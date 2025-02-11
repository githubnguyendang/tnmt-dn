import { Fragment, useEffect, useState } from 'react'
import { Save } from '@mui/icons-material'
import { Grid, Button, DialogActions, TextField, CircularProgress, Autocomplete, Box, Typography } from '@mui/material'
import { getData, saveData } from 'src/api/axios'
import { FormDuBaoAoHoState } from './FormInterface'
import FormatCellValue from 'src/@core/components/calculate-data-river'

const LakeForeCastTForm = ({ data, setPostSuccess }: any) => {
  const [loading, setLoading] = useState<boolean>(false)
  const [hoChua, setHoChua] = useState([])
  const [thongSoQC, setThongSoQC] = useState([])
  const [forecastResult, setForecastResult] = useState<any>(null)
  const [report1Data, setreport1Data] = useState<FormDuBaoAoHoState>({
    id: data?.id || 0,
    idHoChua: data?.idHoChua || 0,
    idMucPL: data?.idMucPL || 0,
    cnnBOD: data?.cnnBOD || 0,
    cnnCOD: data?.cnnCOD || 0,
    cnnAmoni: data?.cnnAmoni || 0,
    cnnTongN: data?.cnnTongN || 0,
    cnnTongP: data?.cnnTongP || 0,
    cnnTSS: data?.cnnTSS || 0,
    cnnColiform: data?.cnnColiform || 0,
    vh: data?.vh || 0,
    fs: data?.fs || 0
  })

  //dataselect
  useEffect(() => {
    setLoading(true)
    const getDataForSelect = async () => {
      try {
        const list = await getData('cong-trinh/danh-sach', { loai_ct: 5 })
        const quychuan = await getData('ThongSoCLNDuBao/danhsach')

        setHoChua(list)
        setThongSoQC(quychuan)
      } catch (error) {
        console.log(error)
      } finally {
        setLoading(false)
      }
    }
    getDataForSelect()
  }, [])
  const [saving, setSaving] = useState(false)

  const handleChange = (prop: keyof FormDuBaoAoHoState) => (value: any) => {
    setreport1Data({ ...report1Data, [prop]: value })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault()

    const handleApiCall = async () => {
      setForecastResult(null)
      setSaving(true)
      try {
        const res = await saveData('DuBaoKNTNNuocAo/du-bao', report1Data)
        console.log(res) // Log the response to verify it

        // Check res instead of res.data because saveData already returns response.data
        if (res) {
          console.log(res) // Log data directly
          setForecastResult(res) // Use res instead of res.data

          // Reset form fields
          setreport1Data({
            id: 0,
            idHoChua: 0,
            idMucPL: 0,
            cnnBOD: 0,
            cnnCOD: 0,
            cnnAmoni: 0,
            cnnTongN: 0,
            cnnTongP: 0,
            cnnTSS: 0,
            cnnColiform: 0,
            vh: 0,
            fs: 0
          })

          // Notify success
          if (typeof setPostSuccess === 'function') setPostSuccess(true)
        }
      } catch (error) {
        console.log(error)
      } finally {
        setSaving(false)
      }
    }

    // Call the function
    handleApiCall()
  }

  return (
    <Box>
      <Grid container spacing={3}>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <Autocomplete
            size='small'
            options={hoChua}
            getOptionLabel={(option: any) => `${option.tenCT} `}
            value={hoChua?.find((option: any) => option.id === report1Data.idHoChua) || null}
            onChange={(_, value) => handleChange('idHoChua')(value?.id || 0)}
            renderInput={params => (
              <TextField
                {...params}
                fullWidth
                label='Chọn hồ chứa'
                InputProps={{
                  ...params.InputProps,
                  endAdornment: (
                    <Fragment>
                      {loading && <CircularProgress color='primary' size={20} />}
                      {params.InputProps.endAdornment}
                    </Fragment>
                  )
                }}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
          <Autocomplete
            size='small'
            options={thongSoQC}
            getOptionLabel={(option: any) => `${option.mucPLCLNuoc} `}
            value={thongSoQC?.find((option: any) => option.id === report1Data.idMucPL) || null}
            onChange={(_, value) => handleChange('idMucPL')(value?.id || 0)}
            renderInput={params => (
              <TextField
                {...params}
                fullWidth
                label='Chọn mức phân loại chất lượng nước theo QCVN08/2023'
                InputProps={{
                  ...params.InputProps,
                  endAdornment: (
                    <Fragment>
                      {loading && <CircularProgress color='primary' size={20} />}
                      {params.InputProps.endAdornment}
                    </Fragment>
                  )
                }}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} md={12} sm={12} sx={{ my: 2 }}>
          <Grid container spacing={2}>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='BOD5'
                fullWidth
                placeholder=''
                value={report1Data.cnnBOD || ''}
                onChange={event => handleChange('cnnBOD')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='COD'
                fullWidth
                placeholder=''
                value={report1Data.cnnCOD || ''}
                onChange={event => handleChange('cnnCOD')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Amoni'
                fullWidth
                placeholder=''
                value={report1Data.cnnAmoni || ''}
                onChange={event => handleChange('cnnAmoni')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Tổng N'
                fullWidth
                placeholder=''
                value={report1Data.cnnTongN || ''}
                onChange={event => handleChange('cnnTongN')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Tổng P'
                fullWidth
                placeholder=''
                value={report1Data.cnnTongP || ''}
                onChange={event => handleChange('cnnTongP')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Tổng chất rắn lơ lửng TSS'
                fullWidth
                placeholder=''
                value={report1Data.cnnTSS || ''}
                onChange={event => handleChange('cnnTSS')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Tổng coliform'
                fullWidth
                placeholder=''
                value={report1Data.cnnColiform || ''}
                onChange={event => handleChange('cnnColiform')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Dung tích hồ'
                fullWidth
                placeholder=''
                value={report1Data.vh || ''}
                onChange={event => handleChange('vh')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <TextField
                size='small'
                type='text'
                label='Hệ số FS'
                fullWidth
                placeholder=''
                value={report1Data.fs || ''}
                onChange={event => handleChange('fs')(event.target.value)}
              />
            </Grid>
            <Grid item xs={12} md={6} sm={12} sx={{ my: 2 }}>
              <DialogActions>
                <Button disabled={saving} className='btn saveBtn' onClick={handleSubmit}>
                  {saving ? <CircularProgress color='inherit' size={20} /> : <Save />} Dự báo
                </Button>
              </DialogActions>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      {forecastResult && (
        <Grid item xs={12}>
          <Typography variant='h6' color='primary'>
            Kết quả dự báo:
          </Typography>
          <Box>
            {/* Display mtnBOD and other results dynamically */}
            <Typography variant='body1'>{FormatCellValue(forecastResult.mtnBOD, 'BOD')}</Typography>
            <Typography variant='body1'>{FormatCellValue(forecastResult.mtnCOD, 'COD')}</Typography>
            <Typography variant='body1'>{FormatCellValue(forecastResult.mtnAmoni, 'Amoni')}</Typography>
            <Typography className='text-dubao' variant='body1'>{FormatCellValue(forecastResult.mtnTongN, 'Tổng N')}</Typography>
            <Typography className='text-dubao' variant='body1'>{FormatCellValue(forecastResult.mtnTongP, 'Tổng P')}</Typography>
            <Typography className='text-dubao' variant='body1'>{FormatCellValue(forecastResult.mtnTSS, 'TSS')}</Typography>
            <Typography className='text-dubao' variant='body1'>{FormatCellValue(forecastResult.mtnColiform, 'Coliform')}</Typography>
          </Box>
        </Grid>
      )}
    </Box>
  )
}

export default LakeForeCastTForm
