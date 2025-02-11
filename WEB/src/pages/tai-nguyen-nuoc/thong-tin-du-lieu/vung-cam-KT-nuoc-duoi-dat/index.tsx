import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import Error401 from 'src/pages/401'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'
import VungCamKTNuocDuoiDat from 'src/views/data-information/vung-cam-KT-nuoc-duoi-dat'

const VungCamKTNuocDuoiDatPage = () => {
  const { hasPermission } = useRequireAuth()
  const router = useRouter()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(router.pathname.split('/')[3], 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, router.pathname])

  if (hasAccess === null) {
    return <BoxLoading /> // Or any loading indicator
  }

  return hasAccess ? <VungCamKTNuocDuoiDat /> : <Error401 />
}

export default VungCamKTNuocDuoiDatPage
