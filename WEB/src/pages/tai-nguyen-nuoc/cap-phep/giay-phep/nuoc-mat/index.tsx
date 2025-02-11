import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import ListLicenses from 'src/views/license'
import Error401 from 'src/pages/401'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'

const SurfaceWaterPage = () => {
  const { hasPermission } = useRequireAuth()
  const router = useRouter()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission('tai-nguyen-nuoc/cap-phep/giay-phep/nuoc-mat', 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, router.pathname])

  if (hasAccess === null) {
    return <BoxLoading /> // Or any loading indicator
  }

  return hasAccess ? <ListLicenses /> : <Error401 />
}

export default SurfaceWaterPage
