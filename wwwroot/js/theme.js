(() => {
  'use strict'

  const getStoredTheme = () => localStorage.getItem('theme')
  const setStoredTheme = theme => localStorage.setItem('theme', theme)

  const getPreferredTheme = () => {
    const storedTheme = getStoredTheme()
    if (storedTheme) {
      return storedTheme
    }

    return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light'
  }

  const showHideThemeToggles = () => {
    const lightThemeSwitcherButton = document.querySelector('#light-theme-toggle-button')
    const darkThemeSwitcherButton = document.querySelector('#dark-theme-toggle-button')

    console.log("Running showHideThemeToggles()...")
    console.log("getStoredTheme() is " + getStoredTheme())
    console.log("lightThemeSwitcherButton.getAttribute('data-bs-theme-value') is " + lightThemeSwitcherButton.getAttribute('data-bs-theme-value'))
    console.log("darkThemeSwitcherButton.getAttribute('data-bs-theme-value') is " + darkThemeSwitcherButton.getAttribute('data-bs-theme-value'))



    if (lightThemeSwitcherButton.getAttribute('data-bs-theme-value') === getStoredTheme()) {

      console.log("hiding lightThemeSwitcherButton")
      lightThemeSwitcherButton.style.display = 'none'
    } else {

      console.log("showing lightThemeSwitcherButton")
      lightThemeSwitcherButton.style.display = ''
    }

    if (darkThemeSwitcherButton.getAttribute('data-bs-theme-value') === getStoredTheme()) {

      console.log("hiding darkThemeSwitcherButton")
      darkThemeSwitcherButton.style.display = 'none'
    } else {

      console.log("showing darkThemeSwitcherButton")
      darkThemeSwitcherButton.style.display = ''
    }

  } 

  const setTheme = theme => {
    if (theme === 'auto' && window.matchMedia('(prefers-color-scheme: dark)').matches) {
      document.documentElement.setAttribute('data-bs-theme', 'dark')
    } else {
      document.documentElement.setAttribute('data-bs-theme', theme)
    }    
  }

  setTheme(getPreferredTheme())

  const showActiveTheme = (theme, focus = false) => {
    const themeSwitcher = document.querySelector('#bd-theme')

    if (!themeSwitcher) {
      return
    }

    const themeSwitcherText = document.querySelector('#bd-theme-text')
    const activeThemeIcon = document.querySelector('.theme-icon-active use')
    const btnToActive = document.querySelector(`[data-bs-theme-value="${theme}"]`)
    const svgOfActiveBtn = btnToActive.querySelector('svg use').getAttribute('href')

    document.querySelectorAll('[data-bs-theme-value]').forEach(element => {
      element.classList.remove('active')
      element.setAttribute('aria-pressed', 'false')
    })

    btnToActive.classList.add('active')
    btnToActive.setAttribute('aria-pressed', 'true')
    activeThemeIcon.setAttribute('href', svgOfActiveBtn)
    const themeSwitcherLabel = `${themeSwitcherText.textContent} (${btnToActive.dataset.bsThemeValue})`
    themeSwitcher.setAttribute('aria-label', themeSwitcherLabel)

    if (focus) {
      themeSwitcher.focus()
    }

  }

  window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', () => {
    const storedTheme = getStoredTheme()
    if (storedTheme !== 'light' && storedTheme !== 'dark') {
      setTheme(getPreferredTheme())
    }
  })


  window.addEventListener('DOMContentLoaded', () => {
    showActiveTheme(getPreferredTheme())

    document.querySelectorAll('[data-bs-theme-value]')
      .forEach(toggle => {
        toggle.addEventListener('click', () => {
          const theme = toggle.getAttribute('data-bs-theme-value')
          setStoredTheme(theme)
          setTheme(theme)
          showActiveTheme(theme, true)
        })
        toggle.addEventListener('click', showHideThemeToggles)
      })
    

      showHideThemeToggles()

  })
})()