import { Box, Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import Navbar from "./Navbar";
import { Outlet } from "react-router-dom";

function App() {
  const darkMode = true;
  const palleteType = darkMode ? 'dark' : 'light'
  const theme = createTheme({
    palette: {
      mode: palleteType,
      background: {
        default: (palleteType === 'light') ? '#eaeaea' : '#121212'
      }
    }
  })

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline/>
    <Navbar />
    <Box
      sx={{
        minHeight: '100vh',
        background: darkMode ? '#121212' : '#eaeaea'
      }}>
      <Container maxWidth='xl' sx={{mt: 14}}>      
      <Outlet />
    </Container>
    </Box>
    </ThemeProvider>
  )
}

export default App
