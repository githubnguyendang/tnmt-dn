import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import Error401 from 'src/pages/401'
import { useEffect, useState } from 'react'
import KTSDPhaiDangKy from 'src/views/data-information/cong-trinh-KTSD-TNN/KTSD-phai-dang-ky'
import BoxLoading from 'src/@core/components/box-loading'

const KTSDPhaiDangKyPage = () => {
  const { hasPermission } = useRequireAuth()
  const router = useRouter()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(router.pathname.split('/').slice(0, -2).join('/'), 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, router.pathname])

  if (hasAccess === null) {
    return <BoxLoading />// Or any loading indicator
  }

  return hasAccess ? <KTSDPhaiDangKy /> : <Error401 />
}

export default KTSDPhaiDangKyPage
