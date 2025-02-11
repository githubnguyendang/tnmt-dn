import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import DieuTraXaThai from 'src/views/data-information/dieu-tra/xa-thai'
import Error401 from 'src/pages/401'
import { useEffect, useState } from 'react'
import BoxLoading from 'src/@core/components/box-loading'

const DieuTraXaThaiPage = () => {
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
    return <BoxLoading /> // Or any loading indicator
  }

  return hasAccess ? <DieuTraXaThai /> : <Error401 />
}

export default DieuTraXaThaiPage
