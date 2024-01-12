﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly NavigationManager _navigationManager;
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public OrderService(HttpClient http,
            AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigationManager)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }
        
        public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
            return result.Data;
        }

        public async Task PlaceOrder()
        {
            if( await IsUserAuthenticated() )
            {
                await _http.PostAsync("api/order", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
}