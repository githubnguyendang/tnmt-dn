import React, { useState, useEffect } from 'react'
import { apiUrl } from 'src/api/config'
import { pdfjs, Document, Page } from 'react-pdf'
import { Box, Button, Typography } from '@mui/material'
import DialogControlShowPDF from './dialog'
import BoxLoading from '../box-loading'
import { Download } from '@mui/icons-material'

interface ShowFilePDFProps {
  src: string | null
  name: string | null
}

const ShowFilePDF = ({ src, name }: ShowFilePDFProps) => {
  const [fileUrl, setFileUrl] = useState<any>(null)
  const [numPages, setNumPages] = useState(0)
  const [loading, setLoading] = useState(false)
  const fileName = src?.split('/').slice(-1).pop()
  const filePath = src?.split('/').slice(0, -1).join('/')

  useEffect(() => {
    pdfjs.GlobalWorkerOptions.workerSrc = `//cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.min.js`

    if (src && src !== null) {
      handleReadFile()
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [src])

  const handleReadFile = async () => {
    try {
      setLoading(true)
      const response = await fetch(`${apiUrl}/file/readfile?FilePath=${filePath}&FileName=${fileName}`)

      if (!response.ok) {
        throw new Error('File not found')
      }

      const blob = await response.blob()
      const url = URL.createObjectURL(blob)
      setFileUrl(url)

      // Get the total number of pages
      const pdf = await pdfjs.getDocument(url).promise
      setNumPages(pdf.numPages)
    } catch (error: any) {
      console.error(error.message)
    } finally {
      setLoading(false)
    }
  }

  // Generate an array of <Page> components for all pages
  const renderPages = () => {
    const pages = []
    for (let pageNumber = 1; pageNumber <= numPages; pageNumber++) {
      pages.push(
        <Page key={pageNumber} pageNumber={pageNumber} renderTextLayer={false} renderAnnotationLayer={false} />
      )
    }

    return pages
  }

  const openPdfDialog = async (openDialogs: any) => {
    openDialogs(
      loading ? (
        <Box>
          <BoxLoading />
        </Box>
      ) : fileUrl ? (
        <Document file={fileUrl} loading={loading}>
          {renderPages()}
        </Document>
      ) : (
        <Box>KHÔNG CÓ FILE HIỂN THỊ</Box>
      ),
      name
    )
  }

  const downloadFile = () => {
    if (fileUrl) {
      const link = document.createElement('a')
      link.href = fileUrl
      link.download = `${name}.pdf` || 'download.pdf'
      document.body.appendChild(link)
      link.click()
      document.body.removeChild(link)
    }
  }

  return (
    <Box>
      <DialogControlShowPDF>
        {(openDialogs: any) => (
          <Box display={'flex'} alignItems={'center'}>
            <Typography className='btnShowFilePdf' onClick={() => openPdfDialog(openDialogs)}>
              {name && name !== 'null' ? name : ''}
            </Typography>
            {name && name !== 'null' ? (
              <Button className='btnShowFilePdf' onClick={downloadFile}>
                <Download />
              </Button>
            ) : (
              ''
            )}
          </Box>
        )}
      </DialogControlShowPDF>
    </Box>
  )
}

export default ShowFilePDF
